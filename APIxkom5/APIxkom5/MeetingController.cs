using System;
using System.Collections.Generic;

namespace APIxkom5 {
	public class MeetingController {

		private List<Meeting> meetings = new List<Meeting>();
		private Connection connection = new Connection();

		public void AddMeeting(string name) {
			connection.AddMeeting(name);
        }

		public void RemoveMeeting(string name) {
			connection.RemoveMeeting(name);
        }

		public List<Meeting> ReturnMeetings() {
			return connection.GetMeetings();
        }

		/*public void AddUser(string meetingName, User user) {
			connection.AddUser(meetingName, user);

			foreach (Meeting m in meetings) 
			{
				if (m.Name.Equals(meetingName)) 
				{
					m.AddUser(user);
					break;
				}
			}
		}*/

		public void AddUser(User user) {
			connection.AddUser(user);
		}

	}
}