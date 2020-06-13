import React from "react";
import {Link} from "react-router-dom";

const DownloadButton = ({filepath, children}) => {

    return (
        <Link to={filepath} target="_blank" rel="noopener noreferrer" download>
            {children}
        </Link>
    )
};

export default DownloadButton;