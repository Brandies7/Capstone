using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Controls;
using DHTMLX.Scheduler.Data;
using FamilyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;




namespace FamilyPlanner.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar

        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var sched = new DHXScheduler(this);
            sched.Skin = DHXScheduler.Skins.Flat;
            sched.LoadData = true;
            sched.EnableDataprocessor = true;
            sched.InitialDate = new DateTime();
            sched.Config.map_resolve_event_location = true;
            sched.Config.map_resolve_user_location = true;
            sched.Config.full_day = true;
            var check = new LightboxCheckbox("highlighting", "Important");
            check.MapTo = "textColor";
            check.CheckedValue = "red";
            sched.Lightbox.Add(check);
            sched.Lightbox.Add(new LightboxText("text", "Description"));
            sched.Lightbox.Add(new LightboxText("event_location", "Location") { Height = 60 });
            sched.Config.cascade_event_display = true;
            

            var map = new MapView
            {
                ApiKey = "AIzaSyClsFLXBrgtOmpD7C-gyY5tglRiVmlyhmk"
            };
            sched.Views.Add(map);
            sched.LoadData = true;
            map.SectionLocation = "Location";
            sched.DataAction = "Data";
            if (User.IsInRole("Child")) 
            {
                sched.Config.isReadonly = true;
            }

            return View(sched);
        }

        public ContentResult Data(MapView map)
        {
            return (new SchedulerAjaxData(
                new ApplicationDbContext().Events

                .Select(e => new { e.id, e.text, e.start_date, e.end_date, e.event_location, e.location, e.lat, e.lng, e.textColor })




                )
            );

        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            
            var action = new DataAction(actionValues);
            var changedEvent = DHXEventsHelper.Bind<Events>(actionValues);
            var entities = new ApplicationDbContext();
            try
            {
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        entities.Events.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        changedEvent = entities.Events.FirstOrDefault(ev => ev.id == action.SourceId);
                        entities.Events.Remove(changedEvent);
                        break;
                    default:// "update"
                        var target = entities.Events.Single(e => e.id == changedEvent.id);
                        DHXEventsHelper.Update(target, changedEvent, new List<string> { "id" });
                        break;
                }
                entities.SaveChanges();
                action.TargetId = changedEvent.id;
                
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }
            
            return (new AjaxSaveResponse(action));
        }
    }
}
