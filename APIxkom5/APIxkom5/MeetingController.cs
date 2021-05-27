using System;
using System.Collections.Generic;

namespace APIxkom5 {
	public class MeetingController {

		private List<Meeting> meetings = new List<Meeting>();

		public void AddMeeting(string name) {
			meetings.Add(new Meeting(name));
        }

		public void RemoveMeeting(string name) {
			
			foreach(Meeting m in meetings) 
			{
				if (m.Name.Equals(name)) 
				{
					meetings.Remove(m);
					break;
				}
			}

        }

		public List<Meeting> ReturnMeetings() {
			return meetings;
        }

		public void AddUser(string meeting_name, User user) 
		{
			foreach (Meeting m in meetings) 
			{
				if (m.Name.Equals(meeting_name)) 
				{
					m.AddUser(user);
					break;
				}
			}
		}

	}
}