using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Iris.Models;

namespace Iris.Views
{
    public partial class StoryListBox : ListBox
    {
        public StoryListBox()
            : base()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawVariable;
        }

        public StoryListBox(IContainer container)
            : base()
        {
            container.Add(this);
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (e.Index >= this.Items.Count || e.Index < 0)
            {
                return;
            }
            Story story = this.Items[e.Index] as Story;
            if (story == null)
            {
                return;
            }
            string nameText, bodyText, timeText;
            Font boldFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
            if (story.StoryProperty != null)
            {
                bodyText = story.StoryProperty;
                e.ItemHeight = TextRenderer.MeasureText(bodyText, this.Font).Height;
            }
            else
            {
                nameText = story.FromName;
                bodyText = String.Concat(story.Message, ". ", story.LinkName);
                timeText = story.CreateTime.ToString("HH:mm");
                int totalHeight = TextRenderer.MeasureText(nameText, boldFont).Height;
                totalHeight += 5;
                totalHeight += TextRenderer.MeasureText(bodyText, this.Font).Height;
                totalHeight += 5;
                totalHeight += TextRenderer.MeasureText(timeText, this.Font).Height;
                e.ItemHeight = totalHeight;
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= this.Items.Count || e.Index < 0)
            {
                return;
            }
            Story story = this.Items[e.Index] as Story;
            if (story == null)
            {
                return;
            }
            string nameText, bodyText, timeText;
            Font boldFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
            SolidBrush backgroundBrush, textBrush;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundBrush = new SolidBrush(Color.DarkBlue);
                textBrush = new SolidBrush(Color.White);
            }
            else
            {
                backgroundBrush = new SolidBrush(Color.White);
                textBrush = new SolidBrush(Color.Black);
            }
            e.DrawFocusRectangle();
            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            if (story.StoryProperty != null)
            {
                bodyText = story.StoryProperty;
                e.Graphics.DrawString(bodyText, this.Font, textBrush, e.Bounds);
            }
            else
            {
                nameText = story.FromName;
                bodyText = String.Concat(story.Message, ". ", story.LinkName);
                timeText = story.CreateTime.ToString("HH:mm");
                e.Graphics.DrawString(nameText, boldFont, textBrush, new PointF(e.Bounds.X + 5, e.Bounds.Y + 5));
                int stringHeight = TextRenderer.MeasureText(nameText, boldFont).Height;
                e.Graphics.DrawString(bodyText, this.Font, textBrush, new PointF(e.Bounds.X + 5, e.Bounds.Y + stringHeight + 5));
                stringHeight += 5 + TextRenderer.MeasureText(bodyText, this.Font).Height;
                e.Graphics.DrawString(timeText, this.Font, textBrush, new PointF(e.Bounds.X + 5, e.Bounds.Y + stringHeight + 5));
            }
        }

    }
}