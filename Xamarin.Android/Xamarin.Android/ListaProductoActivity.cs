using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Xamarin.Android
{
    [Activity(Label = "ListaProductoActivity")]
    public class ListaProductoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var items = JsonConvert.DeserializeObject<List<string[]>>(Intent.GetStringExtra("data"));

            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            for (int i = 0; i < items.Count; i++)
            {
                var layoutH = new LinearLayout(this);
                layoutH.Orientation = Orientation.Horizontal;

                var txtProducto = new TextView(this);
                txtProducto.Text = items[i][0];
                txtProducto.SetWidth(500);

                var txtCantidad = new TextView(this);
                txtCantidad.Text = items[i][1];
                txtCantidad.SetWidth(500);

                layoutH.AddView(txtProducto);
                layoutH.AddView(txtCantidad);
                layout.AddView(layoutH);
            }
            SetContentView(layout);
        }
    }
}