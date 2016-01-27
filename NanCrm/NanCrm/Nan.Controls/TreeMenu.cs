using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Nan.Controls
{
    public enum MenuType
    {
        Invalid,
        Folder,
        Leaf
    }
    public enum MenuState
    {
        Normal,
        Hover,
        Selected
    }

    public partial class TreeMenu : TreeView
    {
        
        public TreeMenu()
        {
            InitializeComponent();
            base.FullRowSelect = true;
            base.ShowLines = false;
            base.HideSelection = false;
            base.HotTracking = true;
            base.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            base.ItemHeight = 30;
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.Selectable /*|
                ControlStyles.UserMouse*/,
                true
                );
        }

        protected Color m_gradientFolderColorFrom = Color.FromArgb(203, 225, 252);
        //protected Color m_gradientFolderColorFrom = Color.FromArgb(125, 166, 223);
        public Color GradientFolderColorFrom
        {
            get { return m_gradientFolderColorFrom; }
            set { m_gradientFolderColorFrom = value; }
        }
        protected Color m_gradientFolderColorTo = Color.FromArgb(125, 166, 223);
        //protected Color m_gradientFolderColorTo = Color.FromArgb(49, 113, 198);
        public Color GradientFolderColorTo
        {
            get { return m_gradientFolderColorTo; }
            set { m_gradientFolderColorTo = value; }
        }
        //protected Color m_gradientLeafColorFrom = Color.FromArgb(203, 225, 252);
        protected Color m_gradientLeafColorFrom = Color.FromArgb(191, 228, 249);
        public Color GradientLeafColorFrom
        {
            get { return m_gradientLeafColorFrom; }
            set { m_gradientLeafColorFrom = value; }
        }
        //protected Color m_gradientLeafColorTo = Color.FromArgb(125, 166, 223);
        protected Color m_gradientLeafColorTo = Color.FromArgb(75, 182, 239);
        public Color GradientLeafColorTo
        {
            get { return m_gradientLeafColorTo; }
            set { m_gradientLeafColorTo = value; }
        }
        protected Color m_gradientHoverColorFrom = Color.FromArgb(255, 255, 220);
        public Color GradientHoverColorFrom
        {
            get { return m_gradientHoverColorFrom; }
            set { m_gradientHoverColorFrom = value; }
        }
        protected Color m_gradientHoverColorTo = Color.FromArgb(247, 192, 91);
        public Color GradientHoverColorTo
        {
            get { return m_gradientHoverColorTo; }
            set { m_gradientHoverColorTo = value; }
        }
        protected Color m_gradientSelectedColorFrom = Color.FromArgb(247, 218, 124);
        public Color GradientSelectedColorFrom
        {
            get { return m_gradientSelectedColorFrom; }
            set { m_gradientSelectedColorFrom = value; }
        }
        protected Color m_gradientSelectedColorTo = Color.FromArgb(232, 127, 8);
        public Color GradientSelectedColorTo
        {
            get { return m_gradientSelectedColorTo; }
            set { m_gradientSelectedColorTo = value; }
        }

        #region override base function

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Bounds.Height <= 0) return;
            TreeMenuNode node = (TreeMenuNode)e.Node;
            //DrawMenuNode(node);
            DrawMenuNode(e.Graphics, e.Bounds, (TreeMenuNode)e.Node, GetMenuState(e.State));
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            e.Node.Toggle();
        }

        //protected override void OnNodeMouseHover(TreeNodeMouseHoverEventArgs e)
        //{
        //    base.OnNodeMouseHover(e);
        //    TreeMenuNode node = (TreeMenuNode)e.Node;
            
        //}
        #endregion

        private void DrawMenuNode(Graphics g, Rectangle rect, TreeMenuNode node, MenuState state)
        {
            if (node.Type == MenuType.Invalid) return;
            if (node.Type == MenuType.Folder)
            {
                DrawFolder(g, rect, node, state);
            }
            else if (node.Type == MenuType.Leaf)
            {
                DrawLeaf(g, rect, node, state);
            }
        }
        private void DrawFolder(Graphics g, Rectangle rect, TreeMenuNode node, MenuState state)
        {
            Color colorFrom = GetGrandientColor(state, true, true);
            Color colorTo = GetGrandientColor(state, true, false);

            Brush br = new LinearGradientBrush(rect, colorFrom, colorTo, LinearGradientMode.Vertical);
            g.FillRectangle(br, rect.X, rect.Y, rect.Width, rect.Height);
            br.Dispose();

            if (node.Text.Length > 0)
            {
                g.DrawString(node.Text, node.TreeView.Font, Brushes.Black, 10 + node.Level * 15, 10 + rect.Y);
            }
        }
        private void DrawLeaf(Graphics g, Rectangle rect, TreeMenuNode node, MenuState state)
        {
            Color colorFrom = GetGrandientColor(state, false, true);
            Color colorTo = GetGrandientColor(state, false, false);

            Brush br = new LinearGradientBrush(rect,
                colorFrom,
                colorTo,
                90f);
            g.FillRectangle(br, rect.X, rect.Y, rect.Width, rect.Height);
            br.Dispose();

            if (node.Text.Length > 0)
            {
                g.DrawString(node.Text, node.TreeView.Font, Brushes.Black, 10 + node.Level * 15, 10 + rect.Y);
            }
        }

        private Color GetGrandientColor(MenuState state, bool isFolder, bool isFrom)
        {
            Color color = this.BackColor;

            //if (isFolder)
            //{
            //    color = (isFrom ? m_gradientFolderColorFrom : m_gradientFolderColorTo);
            //}
            //else
            {
                switch (state)
                {
                    case MenuState.Hover:
                        color = (isFrom ? m_gradientHoverColorFrom : m_gradientHoverColorTo);
                        break;
                    case MenuState.Normal:
                        if (isFolder)
                        {
                            color = (isFrom ? m_gradientFolderColorFrom : m_gradientFolderColorTo);
                        }
                        else
                        {
                            color = (isFrom ? m_gradientLeafColorFrom : m_gradientLeafColorTo);
                        }
                        break;
                    case MenuState.Selected:
                        color = (isFrom ? m_gradientSelectedColorFrom : m_gradientSelectedColorTo);
                        break;
                    default:
                        break;
                }
            }
            
            return color;
        }

        private MenuState GetMenuState(TreeNodeStates state)
        {
            MenuState ret = MenuState.Normal;
            if (((int)state & (int)TreeNodeStates.Hot) == (int)TreeNodeStates.Hot)
            {
                ret = MenuState.Hover;
            }
            else if (((int)state & (int)TreeNodeStates.Selected) == (int)TreeNodeStates.Selected)
            {
                ret = MenuState.Selected;
            }
            
            return ret;
        }
    }

    public class TreeMenuNode : TreeNode
    {
        public MenuType Type { get; set; }

        public TreeMenuNode(string text, MenuType type):base(text)
        {
            Type = type;
        }
    }
}
