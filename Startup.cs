using Blazored.SessionStorage;
using BlazorStrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrisonFeeAnalysis.Data;
using OrisonFeeAnalysis.Logics.Concrete.General;
using OrisonFeeAnalysis.Logic.Contract.General;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using OrisonFeeAnalysis.Logics.Contract.Main;
using OrisonFeeAnalysis.Logics.Concrete.Main;
using OrisonFeeAnalysis.Logics.Contract.BoldReport;
using OrisonFeeAnalysis.Logics.Concrete.BoldReport;
using OrisonFeeAnalysis.Services;
using OrisonFeeAnalysis.Contract.Financial.Main;
using OrisonFeeAnalysis.Concrete.Financial.Main;
using OrisonFeeAnalysis.Contract.General;
using OrisonFeeAnalysis.Concrete.General;
using Blazored.Toast;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using OrisonFeeAnalysis.Shared;
using Microsoft.Extensions.Options;
using OrisonFeeAnalysis.Contract;
using OrisonFeeAnalysis.Concrete;

namespace OrisonFeeAnalysis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(client => new HttpClient { BaseAddress = new Uri(Configuration.GetValue<string>("APIURL:BaseUrl")) });
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
            services.AddBlazoredSessionStorage();
            services.AddBootstrapCss();
            services.AddTransient<IUserLoginManager, UserLoginManager>();
            services.AddTransient<IAccountsMain, AccountsMainManager>();
            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<Logics.Contract.BoldReport.IBoldReportManager, Logics.Concrete.BoldReport.BoldReportManager > ();
            services.AddScoped<BoldReportService>();
            services.AddScoped<URLService>();
            services.AddBlazoredToast();
            services.AddTransient<IVoucherDocuments, VoucherDocumentsManager>();
            services.AddTransient<IVoucherMasterManager, VoucherMasterManager>();
            services.AddTransient<FinServices>();
            services.AddTransient<GeneralServices>();
            services.AddTransient<IInvAccounts, InvAccounts>();
            services.AddTransient<IVoucher, VoucherManager>();
            services.AddTransient<IVoucherAllocation, VoucherAllocationManager>();
            services.AddTransient<IVEntry, VEntryManager>();
            services.AddTransient<ICheque, ChequeManager>();
            services.AddTransient<IAccountAllocation, AccountAllocationManager>();
            services.AddTransient<IFinancialManager, FinancialManager>();
            services.AddTransient<IAccountList, AccountListManager>();
            services.AddTransient<TaxInvoiceService>();
            services.AddTransient<ReceiptService>();
            services.AddTransient<FinVoucherEntryService>();
            services.AddTransient<ICardList, CardListManager>();
            services.AddTransient<Contract.IBoldReportManager, Concrete.BoldReportManager>();
            services.AddTransient<IOptionalManager, OptionalManager>();
            services.AddTransient<IStudentMaster, StudentMaster>();
            services.AddTransient<IPostingManager, PostingManager>();
            services.AddTransient<IMerryLandStudentMaster, MerryLandStudentMaster>();
            services.AddTransient<IStudentManager, StudentManager>();


            //For Arabic Language
            services.AddLocalization();
            services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Define the list of cultures your app will support
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("en-US"),
                    //new CultureInfo("de"),
                    //new CultureInfo("fr"),
                    new CultureInfo("ar-AE"),
                    //new CultureInfo("zh"),
                };

                // Set the default culture
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Register BoldReport license
            Bold.Licensing.BoldLicenseProvider.RegisterLicense("H35tjXWi+KGAe+ZrSbc99mpX8AihM/x/3yr6iak0JWY=");
            //Arabic Language Licence
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzQ0NjgzQDMyMzAyZTMyMmUzME1URlAvS2RlcGVpaGQ1LzlsQzREUElxMGdPTTl0TnJIbUdaOENVMWp1L1U9");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//added for document upload & Bold Reports to enable controllers
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
