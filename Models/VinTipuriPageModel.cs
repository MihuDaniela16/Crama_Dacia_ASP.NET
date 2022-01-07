using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Crama_Dacia_ASP.NET.Data;

namespace Crama_Dacia_ASP.NET.Models
{
    public class VinTipuriPageModel : PageModel
    {
        public List<AlegeTipData> AlegeTipDataList;
        public void PopulateAlegeTipData(Crama_Dacia_ASP.NETContext context, Vin vin)
        {
            var allTipuri = context.Tip;
            var vinTipuri = new HashSet<int>(
            vin.VinTipuri.Select(c => c.TipID)); //
            AlegeTipDataList = new List<AlegeTipData>();
            foreach (var cat in allTipuri)
            {
                AlegeTipDataList.Add(new AlegeTipData
                {
                    TipID = cat.ID,
                    Nume = cat.NumeTip,
                    Alege = vinTipuri.Contains(cat.ID)
                });
            }
        }
        public void UpdateVinTipuri(Crama_Dacia_ASP.NETContext context,
        string[] selectedTipuri, Vin vinToUpdate)
        {
            if (selectedTipuri == null)
            {
                vinToUpdate.VinTipuri = new List<VinTip>();
                return;
            }
            var selectedTipuriHS = new HashSet<string>(selectedTipuri);
            var VinTipuri = new HashSet<int>
            (vinToUpdate.VinTipuri.Select(c => c.Tip.ID));
            foreach (var cat in context.Tip)
            {
                if (selectedTipuriHS.Contains(cat.ID.ToString()))
                {
                    if (!VinTipuri.Contains(cat.ID))
                    {
                        vinToUpdate.VinTipuri.Add(
                        new VinTip
                        {
                            VinID = vinToUpdate.ID,
                            TipID = cat.ID
                        });
                    }
                }
                else
                {
                    if (VinTipuri.Contains(cat.ID))
                    {
                        VinTip courseToRemove = vinToUpdate.VinTipuri.SingleOrDefault(i => i.TipID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }

}
