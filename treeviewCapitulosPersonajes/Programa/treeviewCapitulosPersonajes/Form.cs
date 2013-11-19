using System;
using System.Drawing;
using System.Windows.Forms;

namespace treeviewCapitulosPersonajes{
	public class Form1 : Form
	{
	    private TreeView treeView1;
	    public Form1()
	    {
	        treeView1 = new TreeView();

	        this.SuspendLayout();

	        // Initialize treeView1.
	        treeView1.Location = new Point(0, 25);
	        treeView1.Size = new Size(292, 248);
	        treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | 
	            AnchorStyles.Bottom | AnchorStyles.Right;

	        // Add nodes to treeView1.
	        TreeNode node;
	        for (int x = 0; x < 3; ++x)
	        {
	            // Add a root node.
	            node = treeView1.Nodes.Add(String.Format("Node{0}", x*4));
	            for (int y = 1; y < 4; ++y)
	            {
	                // Add a node as a child of the previously added node.
	                node = node.Nodes.Add(String.Format("Node{0}", x*4 + y));
	            }
	        }

	        // Initialize the form.
	        this.ClientSize = new Size(292, 273);
	        this.Controls.AddRange(new Control[] 
	            { treeView1 } );

	        this.ResumeLayout(false);
	    }
	}
}