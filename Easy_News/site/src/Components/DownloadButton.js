import React from "react";

const DownloadButton = ({filepath, children}) => {

    return (
        <a href={filepath} target="_blank" rel="noopener noreferrer" download={filepath}>
            {children}
        </a>
    )
};

export default DownloadButton;