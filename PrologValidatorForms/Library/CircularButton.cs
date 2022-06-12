using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace PrologValidatorForms.Library
{
    /// <summary>
    /// Klasa odpowiedzialna za zaokraglanie elementow
    /// </summary>
    public class CircularButton: Button
    {
        /// <summary>
        /// Metoda zaokrąglająca obiekty
        /// </summary>
        /// <param name="pevent">Odwolanie do klasy</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(g);
            base.OnPaint(pevent);
        }
    }
}
