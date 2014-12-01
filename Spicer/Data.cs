using AutoMapper;
using Spicer.Model;
using Spicer.ViewModel;

namespace Utils
{
    public static class Data
    {
        public static string Token { get; set; }

        static Data()
        {
            Token = null;

            Mapper.CreateMap<UserModel, LoginViewModel>()
                .ForMember(x => x.Username, a => a.MapFrom(x => x.Username))
                .ForMember(x => x.Password, a => a.MapFrom(x => x.Password));

            Mapper.CreateMap<FantasyModel, FantasyViewModel>()
                .ForMember(x => x.Title, a => a.MapFrom(x => x.Title))
                .ForMember(x => x.ImgUrl, a => a.MapFrom(x => x.ImgUrl));
        }

        public enum StoredDataType
        {
            Notifications
        }

        //public async static Task<bool> LoadPins()
        //{
        //    Logs.Output.ShowOutput("------------------------LOAD PINS BEGIN------------------");

        //    var serializer = new JsonSerializer();

        //    try
        //    {
        //        if (File.Exists(ApplicationData.Current.LocalFolder.Path + "\\" + DataPinsFile) == true)
        //        {
        //            // Get the app data folder and create or replace the file we are storing the JSON in.            
        //            var textFile = await ApplicationData.Current.LocalFolder.GetFileAsync(DataPinsFile);

        //            // read the JSON string!
        //            using (var sw = new StreamReader(textFile.Path))
        //            using (JsonReader reader = new JsonTextReader(sw))
        //            {
        //                var list = serializer.Deserialize<List<PMPinModel>>(reader);
        //                Logs.Output.ShowOutput("Deserialized " + list.Count.ToString() + " pins");

        //                var pc = new PMPinController();

        //                foreach (var pmPinModel in list.Where(pmPinModel => PMMapPinController.IsPinUnique(pmPinModel) == true))
        //                {
        //                    //pmPinModel.ShowPinContent();
        //                    PMMapPinController.AddPinToMap(pmPinModel);
        //                    PinsList.Add(pmPinModel);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Logs.Output.ShowOutput("Storage file does not exist");
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        Logs.Error.ShowError("LoadPins", exp, Logs.Error.ErrorsPriority.NotCritical);
        //    }
            
        //    Logs.Output.ShowOutput("------------------------LOAD PINS END------------------");
        //    return true;
        //}

        //public async static Task<bool> SaveData(StoredDataType dataType)
        //{
        //    string dataFilePath = null;
        //    Object list = null;

        //    switch (dataType)
        //    {
        //        case StoredDataType.Notifications:
        //            Logs.Output.ShowOutput("------------------------SAVE PINS BEGIN------------------");
        //            break;
        //    }

        //    var serializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore };

        //    // Get the app data folder and create or replace the file we are storing the JSON in.            
        //    StorageFile textFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(dataFilePath, CreationCollisionOption.ReplaceExisting);

        //    // write the JSON string!
        //    using (var sw = new StreamWriter(textFile.Path))
        //    using (JsonWriter writer = new JsonTextWriter(sw))
        //    {
        //        try
        //        {
        //            serializer.Serialize(writer, list);
        //        }
        //        catch (JsonException exp)
        //        {
        //            Logs.Error.ShowError(exp);
        //        }
        //    }
        //    Logs.Output.ShowOutput("------------------------SAVE END------------------");

        //    return true;
        //}

        //public async static Task<bool> LoadFavorites()
        //{
        //    Logs.Output.ShowOutput("------------------------LOAD FAVORITES BEGIN------------------");

        //    var serializer = new JsonSerializer();

        //    try
        //    {
        //        if (File.Exists(ApplicationData.Current.LocalFolder.Path + "\\" + DataContactsFile) == true)
        //        {
        //            // Get the app data folder and create or replace the file we are storing the JSON in.            
        //            var textFile = await ApplicationData.Current.LocalFolder.GetFileAsync(DataContactsFile);

        //            // read the JSON string!
        //            using (var sw = new StreamReader(textFile.Path))
        //            using (JsonReader reader = new JsonTextReader(sw))
        //            {
        //                var list = serializer.Deserialize<List<PMUserModel>>(reader);

        //                if (list != null)
        //                {
        //                    Logs.Output.ShowOutput("Deserialized " + list.Count.ToString() + " favorites");
        //                    foreach (var contact in list)
        //                    {
        //                        Logs.Output.ShowOutput("UserId: " + contact.Id + " username:" + contact.Pseudo);
        //                    }
        //                    foreach (var pmUserModel in list)
        //                    {
        //                        PMMapContactController.AddNewFavoris(pmUserModel);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Logs.Output.ShowOutput("Storage file does not exist");
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        Logs.Error.ShowError("LoadFavorites", exp);
        //    }
        //    Logs.Output.ShowOutput("------------------------LOAD FAVORITES END------------------");
        //    return true;
        //}
    }
}
