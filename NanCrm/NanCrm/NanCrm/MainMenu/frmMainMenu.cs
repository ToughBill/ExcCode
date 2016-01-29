using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.Controls;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NanCrm.Setup;
using Biggy.Data.Json;
using Nan.BusinessObjects;
using Nan.BusinessObjects.BO;

namespace NanCrm
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            AddMenu(null, null);
        }

        private void AddMenu(TreeMenuNode parent, IList<JToken> menus)
        {
            try
            {
                if (parent == null)
                {
                    string menuStr = File.ReadAllText(Path.Combine(Application.StartupPath, @"../../mainMenu/mainMenu.txt"));
                    JObject menuObj = JObject.Parse(menuStr);
                    menus = menuObj["menus"].Children().ToList();
                }
                foreach (JToken ret in menus)
                {
                    if (ret["children"] != null)
                    {
                        IList<JToken> subMenus = ret["children"].Children().ToList();
                        MainMenuTag menuTag = JsonConvert.DeserializeObject<MainMenuTag>(ret.ToString());
                        menuTag.Type = MenuType.Folder;
                        TreeMenuNode newNode = new TreeMenuNode(menuTag.Name, MenuType.Folder);
                        newNode.Tag = menuTag;
                        if(parent == null) 
                        {
                            mainMenu.Nodes.Add(newNode);
                        }
                        else
                        {
                            parent.Nodes.Add(newNode);
                        }
                        AddMenu(newNode, subMenus);
                    }
                    else
                    {
                        MainMenuTag menuTag = JsonConvert.DeserializeObject<MainMenuTag>(ret.ToString());
                        menuTag.Type = MenuType.Leaf;
                        TreeMenuNode newNode = new TreeMenuNode(menuTag.Name, MenuType.Leaf);
                        newNode.Tag = menuTag;
                        if (parent == null)
                        {
                            mainMenu.Nodes.Add(newNode);
                        }
                        else
                        {
                            parent.Nodes.Add(newNode);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void mainMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeMenuNode node = (TreeMenuNode)e.Node;
            MainMenuTag tag = (MainMenuTag)node.Tag;
            switch (tag.ID)
            {
                case MenuID.Setup_Country:
                    Country cty = new Country(BOIDEnum.Country);
                    cty.MdiParent = this.MdiParent;
                    cty.Show();
                    break;
                case MenuID.Setup_Market:
                    
                    break;
                case MenuID.BP_MD:
                    BPMD bpmd = new BPMD(BOIDEnum.BP);
                    bpmd.MdiParent = this.MdiParent;
                    bpmd.Show();
                    break;
                default: break;
            }
        }
    }
}
