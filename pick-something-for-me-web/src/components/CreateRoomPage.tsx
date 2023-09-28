import React from 'react';
import Header from './Header';

const CreateRoomPage: React.FC = () => {
    return (
      <div>
        <Header />
        <div className="container mx-auto p-4">
          <div className="flex space-x-4">
            <button
              className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-lg"
            >
              Create Room
            </button>
            <button
              className="bg-green-500 hover:bg-green-600 text-white px-4 py-2 rounded-lg"
            >
              Join Room
            </button>
          </div>
        </div>
      </div>
    );
  };
  
  export default CreateRoomPage;