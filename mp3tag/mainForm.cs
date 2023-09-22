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
                    bool itemExists = false; // һ����ǣ�����ָʾ�Ƿ������ͬ����

                    foreach (ListViewItem item in lVPendingFiles.Items)
                    {
                        if (item.Text == filename)
                        {
                            itemExists = true; // �ҵ�����ͬ����
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
                lbMessage.Text = "���ڴ���" + item.Text;

                if (cBSkip.Checked)
                {
                    //��������tag��mp3
                    int tagexits = tagExits(item.Text);
                    if (tagexits != 0)
                    {
                        //tag���ڻ�������⣬������
                        //�Ƴ�����
                        lVPendingFiles.Items.RemoveAt(i);
                        //����tagexitsֵ����lVProcessedFiles����δ������Ŀ

                        switch (tagexits)
                        {
                            case 1:
                                newitem = new ListViewItem("tag�Ѵ���δ����" + item.Text);
                                // �����ı���ɫ
                                item.ForeColor = Color.AliceBlue;
                                lVProcessedFiles.Items.Insert(0, newitem);
                                break;

                            case -1:
                                newitem = new ListViewItem("���������ļ���" + item.Text);
                                // �����ı���ɫ
                                item.ForeColor = Color.Red;
                                lVProcessedFiles.Items.Insert(0, newitem);
                                break;

                            case -2:
                                newitem = new ListViewItem("���ִ���" + item.Text);
                                // �����ı���ɫ
                                item.ForeColor = Color.DarkRed;
                                lVProcessedFiles.Items.Insert(0, newitem);
                                break;
                        }


                        continue;
                    }
                }

                int result = modify(item.Text, flag);

                //�Ƴ�����
                lVPendingFiles.Items.RemoveAt(i);
                //����resultֵ����lVProcessedFiles������Ŀ
                switch (result)
                {
                    case 1:
                        newitem = new ListViewItem("����ɣ�" + item.Text);
                        // �����ı���ɫ
                        item.ForeColor = Color.Green;
                        lVProcessedFiles.Items.Insert(0, newitem);
                        break;

                    case -1:
                        newitem = new ListViewItem("��������" + item.Text);
                        // �����ı���ɫ
                        item.ForeColor = Color.Red;
                        lVProcessedFiles.Items.Insert(0, newitem);
                        break;

                    case -2:
                        newitem = new ListViewItem("���ִ���" + item.Text);
                        // �����ı���ɫ
                        item.ForeColor = Color.OrangeRed;
                        lVProcessedFiles.Items.Insert(0, newitem);
                        break;

                }

                Application.DoEvents();
            }

            lbMessage.Text = "������ɣ�";
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
                        //���ִ������������-1
                        return -1;
                }

                var file = TagLib.File.Create(filePath);

                // �޸ı�ǩ
                file.Tag.Title = title; // ���滻Ϊ����Ҫ�ı���
                file.Tag.Performers = new[] { artist }; // ���滻Ϊ����Ҫ��������
                                                        //file.Tag.Album = "��ר��"; // ���滻Ϊ����Ҫ��ר����
                                                        // ���Լ����޸�������ǩ��������ݡ����ɵ�

                // �����޸�
                file.Save();
                //�޸ĳɹ�������1
                return 1;
            }
            catch (Exception ex)
            {
                //�޸�ʧ�ܻ��߳��ִ��󣬷���-2
                return -2;
            }
        }

        private int tagExits(string filePath)
        {
            try
            {
                var file = TagLib.File.Create(filePath);

                // ʹ��TagLib��AudioFile��������׼ȷ���ж�
                if (file is not TagLib.Mpeg.AudioFile)
                {
                    //���������ļ��ģ�����-1
                    return -1;
                }

                // ����ǩ�Ƿ����
                if (file.Tag.IsEmpty)
                {
                    //��ǩ�ǿյģ�����0
                    return 0;
                }
                else
                {
                    //��ǩ���ڵģ�����1
                    return 1;
                }
            }
            catch (Exception ex)
            {
                //������ģ�����-2
                return -2;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lVProcessedFiles.Clear();
        }
    }
}