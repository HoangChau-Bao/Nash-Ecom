import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Category';

class Category extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        console.log(this.props.match.params.page);
        const page = parseInt(this.props.match.params.page, 5) || 0;
        console.log(page);
        this.props.requestCategories(page);
    }

    render() {
        return (
            <div>
                <h1>Categories Manage</h1>
                {renderCategoryTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
    }
}

function renderCategoryTable(props) {
    console.log(props);
    return (
        <div><div className='add'>
            <a href="/addcategory">
                Add new category
            </a>
        </div><table className='table table-striped'>

                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Desc</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {props.categories.map(cat => <tr key={cat.id}>
                        <td>{cat.id}</td>
                        <td>{cat.name}</td>
                        <td>{cat.desc}</td>
                        <td>
                            <a href="/updatecategory">
                                Edit
                            </a>
                        </td>
                    </tr>
                    )}
                </tbody>

            </table></div>

    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.page || 1) - 1;
    const nextStartDateIndex = (props.page || 1) + 1;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/category/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/category/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.categories,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Category);