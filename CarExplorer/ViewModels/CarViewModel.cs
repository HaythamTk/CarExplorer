using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarExplorer.ViewModels
{
    public class CarViewModel
    {
        public int SelectedMakeId { get; set; }
        public int SelectedYear { get; set; }
        public string SelectedVehicleType { get; set; }

        public List<SelectListItem> Makes { get; set; } = new();
    }
}
