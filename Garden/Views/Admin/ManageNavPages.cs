using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Garden.Views.Admin
{
    public static class ManageNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Index => "Index";

        public static string ChangePassword => "ChangePassword";

        public static string AddPlant => "AddPlant";

        public static string Categories => "Categories";

        public static string Companies => "Companies";

        public static string Offers => "Offers";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string AddPlantNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddPlant);

        public static string CategoriesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Categories);

        public static string CompaniesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Companies);

        public static string OffersNavClass(ViewContext viewContext) => PageNavClass(viewContext, Offers);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
