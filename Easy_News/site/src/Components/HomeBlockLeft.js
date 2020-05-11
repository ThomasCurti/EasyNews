import React from "react";
import {Link} from "react-router-dom";

const HomeBlockLeft = ({imageText = "", text = "", image = "", title = "", link}) => {
    return (
        <div className="homeBlock">
            <div className="homeBlockLeft">
                <div className="homeBlockText">{imageText}</div>
                <img className="homeBlockImage" alt={image} src={image}/>
            </div>
            <div className="homeBlockTextLeft">
                <div className="homeBlockTextSubtitle">{title}</div>
                <div className="homeBlockTextText">{text}</div>
                {link &&
                <Link className="homeBlockTextLink" to={link}>En savoir plus ></Link>
                }
            </div>
        </div>
    );
};

export default HomeBlockLeft;