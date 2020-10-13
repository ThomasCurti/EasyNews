import React from "react";
import {Link} from "react-router-dom";

const HomeBlockRight = ({imageText = "", text = "", image = "", title = "", link}) => {
    return (
        <div className="homeBlock">
            <div className="homeBlockRight">
                <div className="homeBlockText">{imageText}</div>
                <img className="homeBlockImage" alt={image} src={image}/>
            </div>
            <div className="homeBlockTextRight">
                <div className="homeBlockTextSubtitle">{title}</div>
                <div className="homeBlockTextText">{text}</div>
                {link &&
                <Link className="homeBlockTextLink" to={link}>En savoir plus ></Link>
                }
            </div>
        </div>
    );
};

export default HomeBlockRight;