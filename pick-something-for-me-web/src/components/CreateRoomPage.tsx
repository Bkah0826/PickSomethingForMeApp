import React, { useState } from 'react';
import axios from 'axios';
import Header from './Header';
import '../styles/styles.scss';

const CreateRoomPage: React.FC = () => {

  //State 
    const [username, setUsername] = useState('');
    const [roomNumber, setRoomNumber] = useState('');
    const [room, setRoom] = useState({
      roomName: '',
      users: [],
      activites: []
        });

    const [roomId, setRoomId] = useState('');

  // Function to handle when the "Create Room" button is clicked
  const handleCreateRoomClick = async () => {
    // Validate username and room number
    if (username.trim() === '' || roomNumber.trim() === '') {
      alert('Please enter a username and room number.');
      return;
    }

    // TODO: Implement the logic to create a room
    try {
      const response = await axios.post('api/RoomController');
    }
  };

  // Function to handle when the "Join Room" button is clicked
  const handleJoinRoomClick = () => {
    // Validate username and room number
    if (username.trim() === '' || roomNumber.trim() === '') {
      alert('Please enter a username and room number.');
      return;
    }

    // TODO: Implement the logic to join a room
  };
return  (
  <div className="container mx-auto p-4">
    <h2 className="text-3xl font-semibold mb-4">Welcome to Let's Do Something</h2>

    {/* Username input */}
    <input
      type="text"
      placeholder="Enter your username"
      value={username}
      onChange={(e) => setUsername(e.target.value)}
      className="w-full mb-4 p-2 border border-gray-300 rounded"
    />

    {/* Room number input */}
    <input
      type="text"
      placeholder="Enter room number"
      value={roomNumber}
      onChange={(e) => setRoomNumber(e.target.value)}
      className="w-full mb-4 p-2 border border-gray-300 rounded"
    />

    {/* Create Room button */}
    <button
      onClick={handleCreateRoomClick}
      className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-lg mr-4"
    >
      Create Room
    </button>

    {/* Join Room button */}
    <button
      onClick={handleJoinRoomClick}
      className="bg-green-500 hover:bg-green-600 text-white px-4 py-2 rounded-lg"
    >
      Join Room
    </button>
  </div>
);
};


  
  export default CreateRoomPage;