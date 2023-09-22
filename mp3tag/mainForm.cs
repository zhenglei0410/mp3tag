namespace mp3tag
{
    using TagLib;
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in oFD.FileNames)
                {
                    bool itemExists = false; // 一个标记，用于指示是否存在相同的项

                    foreach (ListViewItem item in lVPendingFiles.Items)
                    {
                        if (item.Text == filename)
                        {
                            itemExists = true; // 找到了相同的项
                            break;
                        }
                    }


                    if (!itemExists)
                    {
                        lVPendingFiles.Items.Add(filename);
                    }
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            modifyFiles("all");
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            modifyFiles("artist");
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            modifyFiles("title");
        }

        private void modifyFiles(string flag)
        {

            lbMessage.ForeColor = Color.Black;
            lbMessage.Text = "";
            for (int i = lVPendingFiles.Items.Count - 1; i >= 0; i--)
            {
                ListViewItem item = lVPendingFiles.Items[i];

                ListViewItem newitem = new ListViewItem();

                lbMessage.ForeColor = Color.Black;
                lbMessage.Text = "正在处理：" + item.Text;

                if (cBSkip.Checked)
                {
                    //跳过已有tag的mp3
                    int tagexits = tagExits(item.Text);
                    if (tagexits != 0)
                    {
                        //tag存在或出现问题，不处理
                        //移除此项
                        lVPendingFiles.Items.RemoveAt(i);
                        //根据tagexits值，在lVProcessedFiles增加未处理项目

                        switch (tagexits)
                        {
                            case 1:
                                newitem = new ListViewItem("tag已存在未处理：" + item.Text);
                                // 设置文本颜色
                                item.ForeColor = Color.AliceBlue;
                                lVProcessedFiles.Items.Insert(0, newitem);
                                break;

                            case -1:
                                newitem = new ListViewItem("不是音乐文件：" + item.Text);
                                // 设置文本颜色
                                item.ForeColor = Color.Red;
                                lVProcessedFiles.Items.Insert(0, newitem);
                                break;

                            case -2:
                                newitem = new ListViewItem("出现错误：" + item.Text);
                                // 设置文本颜色
                                item.ForeColor = Color.DarkRed;
                                lVProcessedFiles.Items.Insert(0, newitem);
                                break;
                        }


                        continue;
                    }
                }

                int result = modify(item.Text, flag);

                //移除此项
                lVPendingFiles.Items.RemoveAt(i);
                //根据result值，在lVProcessedFiles增加项目
                switch (result)
                {
                    case 1:
                        newitem = new ListViewItem("已完成：" + item.Text);
                        // 设置文本颜色
                        item.ForeColor = Color.Green;
                        lVProcessedFiles.Items.Insert(0, newitem);
                        break;

                    case -1:
                        newitem = new ListViewItem("参数错误：" + item.Text);
                        // 设置文本颜色
                        item.ForeColor = Color.Red;
                        lVProcessedFiles.Items.Insert(0, newitem);
                        break;

                    case -2:
                        newitem = new ListViewItem("出现错误：" + item.Text);
                        // 设置文本颜色
                        item.ForeColor = Color.OrangeRed;
                        lVProcessedFiles.Items.Insert(0, newitem);
                        break;

                }

                Application.DoEvents();
            }

            lbMessage.Text = "处理完成！";
            lbMessage.ForeColor = Color.Red;

        }

        private int modify(string filePath, string flag)
        {
            try
            {
                string artist = "";
                string title = "";
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                switch (flag)
                {
                    case "all":
                        title = fileName.Trim();
                        break;

                    case "artist":
                        if (fileName.Split('-').Length > 1)
                        {
                            artist = fileName.Split("-")[0].Trim();
                            title = fileName.Split("-")[1].Trim();
                        }
                        else
                        {
                            title = fileName.Trim();
                        }
                        break;

                    case "title":
                        if (fileName.Split('-').Length > 1)
                        {
                            title = fileName.Split("-")[0].Trim();
                            artist = fileName.Split("-")[1].Trim();
                        }
                        else
                        {
                            title = fileName.Trim();
                        }
                        break;

                    default:
                        //出现错误参数，返回-1
                        return -1;
                }

                var file = TagLib.File.Create(filePath);

                // 修改标签
                file.Tag.Title = title; // 请替换为你想要的标题
                file.Tag.Performers = new[] { artist }; // 请替换为你想要的艺术家
                                                        //file.Tag.Album = "新专辑"; // 请替换为你想要的专辑名
                                                        // 可以继续修改其他标签，例如年份、流派等

                // 保存修改
                file.Save();
                //修改成功，返回1
                return 1;
            }
            catch (Exception ex)
            {
                //修改失败或者出现错误，返回-2
                return -2;
            }
        }

        private int tagExits(string filePath)
        {
            try
            {
                var file = TagLib.File.Create(filePath);

                // 使用TagLib的AudioFile对象来更准确地判断
                if (file is not TagLib.Mpeg.AudioFile)
                {
                    //不是音乐文件的，返回-1
                    return -1;
                }

                // 检查标签是否存在
                if (file.Tag.IsEmpty)
                {
                    //标签是空的，返回0
                    return 0;
                }
                else
                {
                    //标签存在的，返回1
                    return 1;
                }
            }
            catch (Exception ex)
            {
                //出错误的，返回-2
                return -2;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lVProcessedFiles.Clear();
        }
    }
}