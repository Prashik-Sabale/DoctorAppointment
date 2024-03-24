<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }
    private void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.RouteExistingFiles = false;


        routes.Ignore("{resource}.axd/{*pathInfo}");
        routes.MapPageRoute("reg-doc", "registerDoctor", "~/registerDoctor.aspx");
        routes.MapPageRoute("reg", "register", "~/register.aspx");

        //routes.MapPageRoute("def", "letsAdmin/", "~/letsAdmin/Default.aspx");
        routes.MapPageRoute("dash-admin", "LetsAdmin/dashboard", "~/LetsAdmin/dashboard.aspx");
        
        routes.MapPageRoute("admin-spe-mstr", "LetsAdmin/specialty-master/{speId}", "~/LetsAdmin/specialty-master.aspx", false, new System.Web.Routing.RouteValueDictionary() { { "speId", (object)string.Empty } });
        routes.MapPageRoute("admin-doc-mstr", "LetsAdmin/doctor-register/{docId}", "~/LetsAdmin/doctor-register.aspx", false, new System.Web.Routing.RouteValueDictionary() { { "docId", (object)string.Empty } });
        routes.MapPageRoute("srch-doc", "search-doctor/{searchValue}", "~/search-doctor.aspx", false, new System.Web.Routing.RouteValueDictionary() { { "searchValue", (object)string.Empty } });

        //routes.MapPageRoute("404", "{*url}", "~/404.aspx");
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
