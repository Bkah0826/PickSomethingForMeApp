import React from 'react';

function HomeHeader() {
    return ( 
        <h1 className="font-default">Pick Something For Me!</h1>
    );
} 

export default function Header(){
    return(
        <header>
            <HomeHeader />
        </header>
    );
}