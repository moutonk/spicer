using System;

namespace Utils
{
    class DataConverter
    {
        public void ParseJson(string json, RequestType currentRequestType)
        {
            if (json == null)
            {
                Logs.Error.ShowError("ParseJson: json is null");
                return;
            }
            
            try
            {
                switch (currentRequestType)
                {
                    //case RequestType.ProfilPicture:
                    //    //ParseSignIn(json);
                    //    break;
                }
            }
            catch (Exception e)
            {
                Logs.Error.ShowError(e);
            }
        }

        //private static void ParseProfilPicture(string json)
        //{
        //    try
        //    {
        //        var item = JsonConvert.DeserializeObject<JArray>(json);

        //        if (item == null)
        //            return;

        //        if (item.Count == 1)
        //        {
        //            if (Boolean.Parse(item[0].ToString()) == false)
        //                Logs.Error.ShowError("ParseProfilPicture: no picture / incorrect id", Logs.Error.ErrorsPriority.NotCritical);
        //        }
        //        else
        //        {
        //            var picObj = JsonConvert.DeserializeObject<PMPhotoModel>(item[1].ToString());

        //            if (PMData.ProfilPicturesList.Any(elem => elem.UserId.Equals(picObj.UserId)))
        //                return;

        //            //PMData.UserProfilPicture = Convert.FromBase64String(picObj.Content);
        //            var byteArray = Convert.FromBase64String(picObj.Content);

        //            var pic = new PMPhotoModel { UserId = picObj.UserId, FieldBytes = /*new byte[PMData.UserProfilPicture.Length]*/byteArray };
        //            //PMData.UserProfilPicture.CopyTo(pic.FieldBytes, 0);

        //            PMData.ProfilPicturesList.Add(pic);
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        Logs.Error.ShowError("ParseProfilPicture: error" + exp.Message + exp.StackTrace, Logs.Error.ErrorsPriority.NotCritical);
        //    }
        //}

        //public static PMNotificationModel ParseNotification(NotificationEventArgs e)
        //{
        //    //wp:Param: ?type=3&contentId=5&content=k.k
        //    var notif = new PMNotificationModel();

        //    foreach (string key in e.Collection.Keys)
        //    {
        //        Logs.Output.ShowOutput(String.Format("{0}: {1}\n", key, e.Collection[key]));

        //        if (key.Equals("wp:Text1") == true)
        //        {
        //            notif.Text1 = e.Collection[key];
        //        }
        //        else if (key.Equals("wp:Text2") == true)
        //        {
        //            notif.Text2 = e.Collection[key];
        //        }
        //        else if (key.Equals("wp:Param") == true)
        //        {
        //            try
        //            {
        //                string[] items = e.Collection[key].Split(new[] { "?type=", "&contentId=", "&content=" }, StringSplitOptions.RemoveEmptyEntries);
        //                items.ToList().ForEach(item => Logs.Output.ShowOutput(item));

        //                if (items.Count() == 3)
        //                {
        //                    notif.Type = (NotificationCenter.NotificationType)Enum.Parse(typeof(NotificationCenter.NotificationType), items[0], true);
        //                    notif.ContentId = (long)long.Parse(items[1], NumberStyles.None);
        //                    notif.Content = items[2];
        //                }
        //            }
        //            catch (Exception exp)
        //            {
        //                Logs.Error.ShowError("ParseNotification error", exp, Utils.Logs.Error.ErrorsPriority.NotCritical);
        //                return null;
        //            }
        //        }
        //    }
        //    //var item = JsonConvert.DeserializeObject<PMNotificationModel>(json);

        //    notif.DateCreation = DateTime.Now;
        //    PMData.NotificationListToAdd.Add(notif);

        //    Logs.Output.ShowOutput(notif.ToString());

        //    return notif;
        //}
    }   
}
