using Microsoft.Extensions.DependencyInjection;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infra.Ioc
{
    public class DependencyContainers
    {
        public static void RegisterServicse(IServiceCollection service)
        {
            service.AddScoped<IThingIDoService, ThingIDoService>();
            service.AddScoped<ICustomerFeedbackService , CustomerFeedbackService>();
            service.AddScoped<ICustomerLogoService, CustomerLogoService>();
            service.AddScoped<IEducationService , EducationService>();
            service.AddScoped<IExperienceService, ExperienceService>();
            service.AddScoped<ISkillService, SkillService>();
            service.AddScoped<IPortfolioService , PortfolioService>();
            service.AddScoped<ISocialMediaService , SocialMediaService>();
            service.AddScoped<IInformationService , InformationService>();
            service.AddScoped<IMessageService , MessageService>();
            service.AddScoped<IMetaTagSeoService , MetaTagSeoService>();
        }
    }
}
