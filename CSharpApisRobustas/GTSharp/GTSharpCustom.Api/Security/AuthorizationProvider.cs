using GTSharp.Domain.Arguments.User;
using GTSharp.Domain.Interfaces.Services;
using GTSharp.Domain.Resources;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace GTSharpCustom.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IServiceUser serviceUser = _container.Resolve<IServiceUser>();

                AuthUserRequest request = new AuthUserRequest();
                request.Email = context.UserName;
                request.Password = context.Password;

                AuthUserResponse response = serviceUser.AuthUser(request);

                if (serviceUser.IsInvalid())
                {
                    if (response == null)
                    {
                        context.SetError("invalid_grant", Message.X0_IsInvalid.ToFormat(Message.Email + Message.Or + Message.Password));
                        return;
                    }
                }

                serviceUser.ClearNotifications();

                if (response == null)
                {
                    context.SetError("invalid_grant", Message.DataNotFound);
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //Definindo as Claims
                identity.AddClaim(new Claim("User", JsonConvert.SerializeObject(response)));

                var principal = new GenericPrincipal(identity, new string[] { });

                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}