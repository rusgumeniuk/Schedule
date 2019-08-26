using Schedule.Models.JsonHelpers;
using System.Collections.Generic;

namespace Schedule.ViewModels
{
    public class GroupFindViewModel
    {
        public IEnumerable<ResponseGroupData> Groups { get; set; }
    }
}
