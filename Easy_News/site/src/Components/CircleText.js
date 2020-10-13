import React from "react";

const CircleText = ({text}) => {
    return(
        <div className="line">
            <div className="circle">
                <div className="circleText">
                    {text}
                </div>
            </div>
        </div>
    );
};

export default CircleText;