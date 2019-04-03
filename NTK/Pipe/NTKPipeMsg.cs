using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Pipe
{
    /// <summary>
    /// Type de message Pipe
    /// </summary>
    public enum NPMType
    {
        /// <summary>
        /// Demande
        /// </summary>
        GET,
        /// <summary>
        /// Envoi
        /// </summary>
        SET,
    }

    /// <summary>
    /// Classe de base d'un message de canal
    /// </summary>
    public class NTKPipeMsg : EventArgs
    {
        private NPMType type;
        private String text;   

        /// <summary>
        /// Créé un message de base
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        public NTKPipeMsg(NPMType type, String text)
        {
            this.Type = type;
            this.Text = text;

        }
     
        
        /// <summary>
        /// Type de message
        /// </summary>
        public NPMType Type { get => type; set => type = value; }
        /// <summary>
        /// Texte du message
        /// </summary>
        public string Text { get => text; set => text = value; }
    }


   
}
