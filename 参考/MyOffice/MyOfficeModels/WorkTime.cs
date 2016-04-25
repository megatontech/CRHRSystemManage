using System;
using System.Collections.Generic;
using System.Text;

namespace MyOffice.Models
{
    //����ʱ����
    [Serializable]
    public class WorkTime
    {
        private int id;//����ʱ��ID
        private string onDutyTime;//�ϰ�ʱ��
        private string offDutyTime;//�°�ʱ��

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string OnDutyTime
        {
            get { return onDutyTime; }
            set { onDutyTime = value; }
        }
        public string OffDutyTime
        {
            get { return offDutyTime; }
            set { offDutyTime = value; }
        }
    }
}
