Dovetail SDK Web Services
=========================

The Web Services were originally provided with Dovetail SDK. Our resources have changed a lot over the years, so we separated the Web Services out into this repo. They are still a good resource, but have been replaced by the examples of RESTful API usage found in [Dovetail Bootstrap](https://github.com/DovetailSoftware/dovetail-bootstrap).

The documentation for the Web Services APIs has been moved to GitHub pages, and can be found at [Web Services API Documentation](http://dovetailsoftware.github.io/dovetail-sdk-web-services/).

## Web Services Demo

A sample application which demonstrates how to use the Dovetail SDK Web Services Client to access Clarify data using Dovetail SDK Web Services.

In order for the web services demo to work, it requires that a virtual directory is set up under IIS for both the web services host project and the web services demo project.

### Web Server Configuration
Configure the IIS web server to support Dovetail SDK Web Services:

Note: The following assumes IIS version 7.5 on Microsoft Windows 7. Your system may vary slightly.

Open the Internet Information Services Manager

* Select Start and Run.
* Enter inetmgr, and then select OK. The Internet Information Services (ISM) console will open.

Create a new application pool

* Right-click on Application Pools, Add Application Pool,
* Name the pool appropriately, such as *Dovetail SDK Web Services*
* Set the .NET Framework version to *.NET Framework v4.0.x*
* Set the Managed Pipeline Mode to *Integrated*
* Click OK

Create a web application for the Dovetail SDK Web Services Host application

* Expand Sites
* Right-click Default Web Site and select *Add Application*
* In the Alias text box, type a short name (alias) for the directory into which the Dovetail SDK Web Services files were installed (i.e. wsDemo). The alias is what users see as part of the URL path when they are browsing to the Dovetail SDK Web Services web application (for example, http://localhost/wsHost).
* Select the Application Pool that was created above.
* Enter the path, or browse to the directory which contains the Dovetail SDK Web Services application files, i.e. *C:\projects\dovetail-sdk-web-services\src\FChoice.WebServices.Clarify*
* Select OK.

Create a web application for the Dovetail SDK Web Services Demo application

* Expand Sites
* Right-click Default Web Site and select *Add Application*
* In the Alias text box, type a short name (alias) for the directory into which the Dovetail SDK Web Services Demo files were installed (i.e. wsDemoClient). The alias is what users see as part of the URL path when they are browsing to the Dovetail SDK Web Services web application (for example, http://localhost/wsDemo).
* Select the Application Pool that was created above.
* Enter the path, or browse to the directory which contains the Dovetail SDK Web Services Client Demo application files, i.e. *C:\dovetail-sdk-web-services\src\FChoice.WebServices.Clarify.Client.Demo*
* Select OK.


Edit the FChoice.WebServices.Clarify.Client Web.config file to set the database connection information for the Dovetail SDK Web Services Host, i.e. `http://localhost/wsHost/`.

		<add key="fchoice.connectionstring" value="Data Source=.; Initial Catalog=<database>; User Id=<user>; Password=<password>;"/>

Edit the FChoice.WebServices.Clarify.Client.Demo Web.config file to update the url to the web application created above for the Dovetail SDK Web Services Host, i.e. `http://localhost/wsHost/`.

		<add key="fcsdk.webservices.url" value="http://localhost/wsHost/"/>


Browse to the Dovetail SDK Web Services Demo application

* In the left pane, click on the web application that was just created (wsDemo)
* In the right pane, under Manage Application, click Browse *.80 (http)
* This should start your default web browser, start the Dovetail SDK Web Services Demo application, and navigate to the Dovetail SDK Web Services Demo page.
