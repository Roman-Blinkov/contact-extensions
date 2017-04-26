using System;
using MessageUI;
using Plugin.Contacts.Extensions.Abstractions;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using UIKit;

namespace Plugin.Contacts.Extensions
{
    internal class EmailService : IEmailService
    {
        public bool CanSend => MFMailComposeViewController.CanSendMail;

        private MFMailComposeViewController _mailController = null;

        public void Send(string toAddress, string subject, string message)
        {
            if (toAddress.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (subject.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (message.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (!this.CanSend)
            {
                return;
            }

            this._mailController = new MFMailComposeViewController();

            this._mailController.SetToRecipients(new string[] { toAddress });
            this._mailController.SetSubject(subject);
            this._mailController.SetMessageBody(message, isHtml: false);

            this._mailController.Finished += (object s, MFComposeResultEventArgs args) =>
            {
                args.Controller.DismissViewController(animated: true, completionHandler: () => { });
            };

            this.PresentViewController(completionHandler: () => { });
        }

        private void PresentViewController(Action completionHandler)
        {
            var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (viewController == null)
            {
                throw new InvalidOperationException();
            }

            viewController.PresentViewController(this._mailController, animated: true, completionHandler: completionHandler);
        }
    }
}