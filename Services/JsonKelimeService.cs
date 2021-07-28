using Lügavi.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lügavi.Services
{
    public class JsonKelimeService
    {
        public JsonKelimeService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "kelimeler.json"); }
        }

        public IEnumerable<KelimeModel> GetKelimeler()
        {
            using var json = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<KelimeModel[]>(json.ReadToEnd());
        }


        public void AddKelime(KelimeModel newkelime)
        {
            var kelimeler = GetKelimeler();
            newkelime.id = kelimeler.Max(x => x.id) + 1;
            var temp = kelimeler.ToList();
            temp.Add(newkelime);
            IEnumerable<KelimeModel> updatedkelimeler = temp.ToArray();

            using var json = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<KelimeModel>>(
                new Utf8JsonWriter(json,new JsonWriterOptions { Indented=true}), updatedkelimeler);
        }

        public void SilKelime(string Name)
        {
            var kelimeler = GetKelimeler();
            KelimeModel query = kelimeler.Single(x => x.KelimeAdi == Name);
            var temp = kelimeler.ToList();
            temp.Remove(query);
            IEnumerable<KelimeModel> updatedkelimeler = temp.ToArray();
            JsonWrite(updatedkelimeler);

        }

        public void JsonWrite(IEnumerable<KelimeModel> kelime)
        {
            using var json = File.Create(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<KelimeModel>>(
                new Utf8JsonWriter(json, new JsonWriterOptions { Indented = true }), kelime);

        }

        public void UpdateKelime(KelimeModel newkelime)
        {
            var kelimeler = GetKelimeler();
            KelimeModel query = kelimeler.FirstOrDefault(x => x.KelimeAdi == newkelime.KelimeAdi);
            if(query!=null)
            {
                var temp = kelimeler.ToList();
                temp[temp.IndexOf(query)] = newkelime;
                IEnumerable<KelimeModel> updatedkelimeler = temp.ToArray();
                JsonWrite(updatedkelimeler);
            }
            
        }

        public KelimeModel GetKelimeByName(string Name)
        {
            var kelimeler = GetKelimeler();           
            KelimeModel query = kelimeler.FirstOrDefault(x => x.KelimeAdi == Name);
            return query;
        }
        public KelimeModel GetKelimeById(int id)
        {
            var kelimeler = GetKelimeler();
            KelimeModel query = kelimeler.FirstOrDefault(x => x.id == id);
            return query;
        }

    }
}
