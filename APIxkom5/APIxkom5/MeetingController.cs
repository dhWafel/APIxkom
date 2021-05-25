using System;
using System.Collections.Generic;

namespace APIxkom5 {
	public class MeetingController {

		List<Meeting> meetings = new List<Meeting>();

		public void AddMeeting(Meeting data) {
			meetings.Add(data);
        }

		public void RemoveMeeting() {

        }

		public void ReturnMeetings() {

        }

	}
}