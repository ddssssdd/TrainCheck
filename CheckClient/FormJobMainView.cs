using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrainCheck
{
    public partial class FormJobMainView : Form
    {
        public FormJobMainView()
        {
            InitializeComponent();
        }
        private String _keyName;
        public FormJobMainView(JobMain job,String keyName):this()
        {
            _keyName = keyName;
            _Job = job;
            InitView();
        }
        private JobMain _Job;
        private void InitView()
        {
            tvMain.Nodes.Clear();
            tvMain.BeginUpdate();
            try
            {
                string sqlstring = String.Format("select Section,sequence,checkposition,id from DictSpecs where Section='{0}' order by sequence ", _keyName);
                if (!_Job.IsFull)
                    sqlstring = "select Section,sequence,checkposition,id from DictSpecs where isfull<>1 order by sequence";
                using (IDataReader dr = DataAccess.ExecuteReader(sqlstring))
                {
                    TreeNode t1 = null;
                    TreeNode t2 = null;
                    string section="";
                    int sequ = 0;
                    String checkp = "";
                    while (dr.Read())
                    {
                        if (!section.Equals(dr["Section"].ToString()))
                        {
                            section = dr["Section"].ToString();
                            t1 = new TreeNode(section);
                            tvMain.Nodes.Add(t1);
                        }
                        sequ = Int32.Parse(dr["Sequence"].ToString());
                        checkp = dr["CheckPosition"].ToString();
                        t2 = new TreeNode(String.Format("{0}.{1}",sequ,checkp));
                        Specs spec = DbFactory.FindByFilter("ID=" + dr["ID"].ToString(),_Job.IsFull);
                        if (spec != null)
                        {
                            _Job.SetCheckToSpecs(spec);
                            if (spec.IsCheckAll)
                            {
                                t2.Checked = true;
                                t2.ForeColor = System.Drawing.Color.Blue;
                            }
                            foreach (SpecsDetail detail in spec.Items)
                            { 
                                TreeNode node= t2.Nodes.Add(String.Format("{0}({1})--{2}[{3}]",
                                    detail.CheckDetail,detail.CheckMethod,
                                    detail.SpecifiedSizeHeight,detail.KnockPosition));
                                node.Checked = detail.isChecked;
                                if (detail.isDone)
                                    node.ForeColor = System.Drawing.Color.Blue;
                            }
                            
                        }
                        t1.Nodes.Add(t2);
                    }
                    dr.Close();
                }
            }
            finally
            {
                tvMain.EndUpdate();
            }
        }

       

        //private void tvMain_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        //{
        //    if (e.Node.Tag == null)
        //        return;
        //    tvMain.BeginUpdate();
        //    e.Node.Nodes.Clear();
        //    try
        //    {
        //        String id = e.Node.Tag.ToString();
        //        using (IDataReader dr = DataAccess.ExecuteReader("select * from DictSpecsItems where DictSpecsID=" + id))
        //        {
        //            while (dr.Read())
        //            {
        //                e.Node.Nodes.Add(String.Format("{0}({1})--{2}[{3}]",
        //                    dr["CheckDetail"].ToString(),
        //                    dr["CheckMethod"].ToString(),
        //                    dr["SpecifiedSizeHeight"] == DBNull.Value ? "" : dr["SpecifiedSizeHeight"].ToString(),
        //                    dr["KnockPosition"] == DBNull.Value ? "" : dr["KnockPosition"].ToString())).Checked = true;
        //            }
        //            dr.Close();
        //        }
        //    }
        //    finally
        //    {
        //        tvMain.EndUpdate();
        //    }
        //}
           
    }
}