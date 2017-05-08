namespace AutomationTests.Pages.ResizablePage
{
    public static class Constants
    {
        //// Common
        public const string RESIZABLE_URL = "resizable/";
        public const int WAIT_SECCONDS = 20;

        //// Selectors
        public const string DEFAULT_TAB_SELECTOR = "ui-id-1";
        public const string CONSTRAINT_RESIZE_TAB_SELECTOR = "ui-id-3";
        public const string MIN_MAX_SIZE_TAB_SELECTOR = "ui-id-5";
        public const string DEFAULT_RESIZABLE_BOX = "resizable";
        public const string DEFAULT_RESIZE_ANGLE = "//*[@id=\"resizable\"]/div[3]";
        public const string CONSTRAINT_RESIZABLE_BOX = "resizableconstrain";
        public const string CONSTRAINT_RESIZE_ANGLE = "//*[@id=\"resizableconstrain\"]/div[3]";
        public const string MIN_MAX_RESIZABLE_BOX = "resizable_max_min";
        public const string MIN_MAX_RESIZE_ANGLE = "//*[@id=\"resizable_max_min\"]/div[3]";
    }
}
