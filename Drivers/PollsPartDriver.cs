﻿using System.Web;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Urbanit.Polls.Helpers;
using Urbanit.Polls.Models;

namespace Urbanit.Polls.Drivers
{
    public class PollsPartDriver : ContentPartDriver<PollsPart>
    {
        protected override string Prefix
        {
            get
            {
                return "Urbanit.Polls";
            }
        }
        private readonly IOrchardServices _orchardServices;
        public PollsPartDriver(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
        }

        protected override DriverResult Display(PollsPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_Polls",
                () =>
                {
                    var userName = _orchardServices.WorkContext.CurrentUser;
                    var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

                    return shapeHelper.Parts_Polls(UserName: userName);
                }
                    );
        }

        protected override DriverResult Editor(PollsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Polls_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts.Polls",
                    Model: part,
                    Prefix: Prefix
                    ));
        }

        protected override DriverResult Editor(PollsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);

            part.SerializedAnswers = AnswerSerializerHelper.SerializeAnswerList(part.AnswerList);

            return Editor(part, shapeHelper);
        }
    }
}