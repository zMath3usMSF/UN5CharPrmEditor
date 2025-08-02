using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

public class TransparentOverlay : Control
{
    public Image OverlayImage { get; set; }

    public TransparentOverlay()
    {
        this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint, true);

        this.BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (OverlayImage != null)
        {
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorKey(Color.Magenta, Color.Magenta); // Se precisar de cor-chave (opcional)

            e.Graphics.DrawImage(
                OverlayImage,
                new Rectangle(0, 0, this.Width, this.Height),
                0, 0, OverlayImage.Width, OverlayImage.Height,
                GraphicsUnit.Pixel,
                attr
            );
        }
    }
}
