using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;

namespace Musicalog.Client.Entities
{
    public class Album : ObjectBase
    {
        int _AlbumId;
        string _AlbumName;
        string _Artist;
        string _Type;
        int _Stock;
        bool _EditAlbumButton;
        bool _RemoveCatalogButton;

        public int AlbumId
        {
            get{return _AlbumId;}
            set
            {
                if(_AlbumId != value)
                {
                    _AlbumId = value;
                    OnPropertyChanged(() => AlbumId);
                }
                
            }
        }

        public string AlbumName {
            get {return _AlbumName; }
            set
            {
                if (_AlbumName != value)
                {
                    _AlbumName = value;
                    OnPropertyChanged(() => _AlbumName);
                }                
            } 
        }
        
        public string Artist { 
            get {return _Artist;}
            set 
            {
                if (_Artist != value)
                {
                    _Artist = value;
                    OnPropertyChanged(() => _Artist);
                }             
            }
        }
        
        public string Type {
            get { return _Type; }
            set 
            {
                if (_Type != value)
                {
                    _Type = value;
                    OnPropertyChanged(() => _Type);
                }                
            } 
        }
        
        public int Stock {
            get { return _Stock; }
            set
            {
                if (_Stock != value)
                {
                    _Stock = value;
                    OnPropertyChanged(() => _Stock);
                }                
            }
        }
        
        public bool EditAlbumButton {
            get { return _EditAlbumButton; }
            set 
            {
                if (_EditAlbumButton != value)
                {
                    _EditAlbumButton = value;
                    OnPropertyChanged(() => _EditAlbumButton);
                }                
            }
        }
        
        public bool RemoveCatalogButton {
            get { return _RemoveCatalogButton; }
            set
            {
                if (_RemoveCatalogButton != value)
                {
                    _RemoveCatalogButton = value;
                    OnPropertyChanged(() => _RemoveCatalogButton);
                }
                _RemoveCatalogButton = value; 
            } 
        }
    }
}
