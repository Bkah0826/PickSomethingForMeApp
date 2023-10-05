import React, { useState } from 'react';
import axios from 'axios';
import Header from './Header';
import '../styles/styles.scss';

function CreateRoomAndUserPage()  {

    const [userName, setUsername] = useState('');
    const [roomName, setRoomName] = useState('');
    const apiUrl = 'https://localhost:7247/api/Room/CreateRoomAndUser'; //local

  const handleCreateRoomAndUser = async () => {
    //Validate Inputs
    if (userName.trim() === '' || roomName.trim() === '') {
      alert('Please enter a username and a room name.');
      return;
    }
    try {
      const roomAndUserRequest = {
        UserName: userName,
        roomName: roomName
      };

      const response = await axios.post(apiUrl, roomAndUserRequest,{
        headers: {
          'Content-Type': 'application/json',
        },
      });

      console.log('Response from backend:', response.data);

      setUsername('');
      setRoomName(''); 
    } catch (error) {
      console.error('Error:', error);

    }
  };
return  (
  <div className="container mx-auto p-4">
    <h2 className="text-3xl font-semibold mb-4">Welcome to Let's Do Something</h2>

    {/* Username input */}
    <input
      type="text"
      placeholder="Enter your username"
      value={userName}
      onChange={(e) => setUsername(e.target.value)}
      className="w-full mb-4 p-2 border border-gray-300 rounded"
    />

    {/* Room number input */}
    <input
      type="text"
      placeholder="Enter room name" 
      value={roomName}
      onChange={(e) => setRoomName(e.target.value)}
      className="w-full mb-4 p-2 border border-gray-300 rounded"
    />

    {/* Create Room button */}
    <button
      onClick={handleCreateRoomAndUser}
      className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-lg mr-4"
    >
      Create Room
    </button>

    {/* TODO: add join room button */}
</div>
);
};


  
  export default CreateRoomAndUserPage;