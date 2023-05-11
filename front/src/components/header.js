import React from 'react'


export default function Header({ name }) {
    return (
        <>
            <div className={"header"}>
                <div className={"appName"}>
                    <div className={"bleap"}> </div>
                    <span>GERDISC</span>
                </div>
                <div className={"headerOptions"}>
                    <div>Óla, {name}</div>
                </div>
            </div>
            <div className={"headerBreak"}><span></span></div>
            <br></br>
        </>
    );
}