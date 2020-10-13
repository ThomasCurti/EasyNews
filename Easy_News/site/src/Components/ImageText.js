import React from "react";

const ImageText = ({image = "", text = ""}) => {
    return (
      <div>
          <img className="imagesFooterImage" alt={image} src={image}/>
          <div className="imagesFooterText">{text}</div>
      </div>
    );
};

export default ImageText;