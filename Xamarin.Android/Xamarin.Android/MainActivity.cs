﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Content;
using Newtonsoft.Json;

namespace Xamarin.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public List<string[]> miProducto = new List<string[]>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var btn = FindViewById<Button>(Resource.Id.btnAgregar);
            btn.Click += btn_Click;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var producto = FindViewById<EditText>(Resource.Id.txtProducto);
            var cantidad = FindViewById<EditText>(Resource.Id.txtCantidad);
            string[] data = new string[] { producto.Text,cantidad.Text };
            miProducto.Add(data);

            producto.Text = "";
            cantidad.Text = "";

            var intent = new Intent(this, typeof(ListaProductoActivity));
            intent.PutExtra("data", JsonConvert.SerializeObject(miProducto));

            StartActivity(intent);
        }
    }
}