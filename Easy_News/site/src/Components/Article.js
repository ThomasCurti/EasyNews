import React, {useCallback} from "react";
import {Link} from "react-router-dom";

// CSS
import '../Assets/scss/Article.scss';

import {connect} from "react-redux";

// Actions
import {showSearchNo} from '../Actions/Actions'

const Article = ({id, title, description, dispatch}) => {

    const CancelShowSearch = useCallback(() => {
        dispatch(showSearchNo())
    }, [dispatch]);

    return (
        <Link className="articleLinkTo" to={"/article/" + id} onClick={CancelShowSearch}>
            <div className="article">
                <h5>
                    <div className="title">
                        {title}
                    </div>
                </h5>
                <div className="description">
                    {/*Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ut lacinia turpis. Sed tincidunt diam non arcu auctor egestas. Maecenas sed erat nec urna congue viverra. Maecenas ullamcorper aliquet justo, non hendrerit turpis pharetra vel. Morbi quis condimentum erat. Curabitur risus purus, blandit sed pretium at, ornare quis lectus. Sed quis mi nec odio semper accumsan in quis risus. Fusce eros dolor, mattis id interdum eget, lobortis quis lectus. Sed lacus mi, vulputate sed nisl vel, ullamcorper volutpat elit. Curabitur rhoncus eros lectus, vel pharetra mauris varius in. Suspendisse blandit leo id iaculis accumsan. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec eu laoreet eros, at luctus nunc. Nunc eget neque ut eros tristique placerat a eget dui. Maecenas mi justo, consequat lobortis aliquet nec, tempus a purus.*/}
                    {description}
                </div>
            </div>
        </Link>
    );
};

export default connect()(Article);