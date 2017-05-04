using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertRegistrationPageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssesrtSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertNamesErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForRequiredNames.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForRequiredNames.Text);
        }

        public static void AssertPhoneErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForRequiredPhone.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForRequiredPhone.Text);
        }
        public static void AssertHobbyErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForRequiredHobbies.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForRequiredHobbies.Text);
        }
        public static void AssertUserNameErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForRequiredUserName.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForRequiredUserName.Text);
        }
        public static void AssertPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForRequiredPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForRequiredPassword.Text);
        }
        public static void AssertConfirmPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForConfirmPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForConfirmPassword.Text);
        }

        public static void AssertEmailErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForInvalidEmail.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForInvalidEmail.Text);
        }

        public static void AssertPasswordLengthErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPasswordLength.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForPasswordLength.Text);
        }

        public static void AssertPasswordMismatchErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForMismatchPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForMismatchPassword.Text);
        }


    }
}