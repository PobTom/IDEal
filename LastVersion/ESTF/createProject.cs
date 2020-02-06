using System;
using System.Windows.Forms;
using System.IO;

namespace Ideal
{
    class createProject
    {
        public bool creator;
        public string folderPath;
        
        //add folder method 
        public void Addfolder(TreeView folder, string projectname, string pathname)
        {
            if (Directory.Exists(pathname))
            {
                folderPath = pathname + "\\" + projectname;
                if (!Directory.Exists(folderPath))// if the folder does not exist
                {
                    try
                    {
                        Directory.CreateDirectory(folderPath);// create the folder of the project 
                        creator = true;//check the folder has been created 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The folder already exists!", "File exists", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    creator = false;//check the folder has not been created
                }
            }
            else
            {
                MessageBox.Show("Path directory is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public TreeNode ADDNode(TreeView folder, string foldername, string pathname,ContextMenuStrip menu)
        {
            folderPath = pathname + "\\" + foldername;
            //folder.Nodes.Clear();
            var treenode= new TreeNode();
            treenode.Tag = folderPath;// add the path of the folder with the node
            treenode.Text = foldername;
            
            treenode.ContextMenuStrip = menu;
            return treenode;
        }

        public void RemoveFolder(TreeView folder, TreeNode selectedproject)
        {
            if (folder != null)
            {
                folder.Nodes.Remove(selectedproject);//remove from solution
            }
            if (!folder.Nodes.Contains(selectedproject))
            {
                MessageBox.Show("Folder has been removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Removefolderfromcomputer(TreeView folder, TreeNode projectname, string pathname)// remove the folder from computer 
        {    
            if (Directory.Exists(pathname))
            {
                Directory.Delete(pathname, true);
               
                RemoveFolder(folder, projectname);
                creator = true;//check the folder has been created 
            }
            else
            {
                MessageBox.Show("The folder doesn't exist!", "Invalid folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                creator = false;//check the folder has not been removed beacause not found
            }


        }
    }
}
