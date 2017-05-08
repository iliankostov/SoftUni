namespace AutomationTests.Pages.RegistrationPage
{
    public static class Constants
    {
        //// Common
        public const string REGISTRATION_URL = "registration/";
        public const int WAIT_SECCONDS = 20;

        //// Messages
        public const string ERROR_REQUIRED = "* This field is required";
        public const string ERROR_PHONE = "* Minimum 10 Digits starting with Country Code";
        public const string ERROR_EMAIL = "* Invalid email address";
        public const string ERROR_SHORT_PASSWORD = "* Minimum 8 characters required";
        public const string ERROR_PASSWORD_NOT_MATCH = "* Fields do not match";

        //// Selectors
        public const string TITLE_SELECTOR = "title";
        public const string HEADER_SELECTOR = "entry-title";
        public const string FIRST_NAME_SELECTOR = "name_3_firstname";
        public const string LAST_NAME_SELECTOR = "name_3_lastname";
        public const string MARITAL_STATUS_SELECTOR = "radio_4[]";
        public const string HOBBYS = "checkbox_5[]";
        public const string COUNTRY_SELLECTOR = "dropdown_7";
        public const string MOUNTH_SELECTOR = "mm_date_8";
        public const string DAY_SELECTOR = "dd_date_8";
        public const string YEAR_SELECTOR = "yy_date_8";
        public const string PHONE_SELECTOR = "phone_9";
        public const string USERNAME_SELECTOR = "username";
        public const string EMAIL_SELECTOR = "email_1";
        public const string UPLOAD_BUTTON_SELECTOR = "profile_pic_10";
        public const string DESCRIPTION_SELECTOR = "description";
        public const string PASSWORD_SELECTOR = "password_2";
        public const string CONFIRM_PASSWORD_SELECTOR = "confirm_password_password_2";
        public const string _SUBMIT_BUTTON_SELECTOR = "pie_submit";
        public const string SUCCESS_MESSAGE_SELECTOR = "piereg_message";
        public const string ERROR_NAME_SELECTOR = "//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span";
        public const string ERROR_HOBBIES_SELECTOR = "//*[@id=\"pie_register\"]/li[3]/div/div[2]/span";
        public const string ERROR_PHONE_SELECTOR = "//*[@id=\"pie_register\"]/li[6]/div/div/span";
        public const string ERROR_USERNAME_SELECTOR = "//*[@id=\"pie_register\"]/li[7]/div/div/span";
        public const string ERROR_EMAIL_SELECTOR = "//*[@id=\"pie_register\"]/li[8]/div/div/span";
        public const string ERROR_PASSWORD_SELECTOR = "//*[@id=\"pie_register\"]/li[11]/div/div/span";
        public const string ERROR_CONFIRM_PASSWORD_SELECTOR = "//*[@id=\"pie_register\"]/li[12]/div/div/span";
    }
}
