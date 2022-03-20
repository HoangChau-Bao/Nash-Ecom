import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Product';

class Product extends Component {
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
        this.props.requestProducts(page);
    }

    render() {
        console.log(this.props);
        return (
            <div>
                <h1>Products Manage</h1>
                {renderProductTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
    }
}

function renderProductTable(props) {
    console.log(props);
    return (
        <div>
            <div className='add'>
                <a href="/addproduct">
                    Add new product
                </a>
                <p>    </p>
                <a href="/updateproduct">
                    Edit product
                </a>
            </div>
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Desc</th>
                        <th>Cost</th>
                        <th>Category</th>
                        <th>CreatedDate</th>
                        <th>UpdateDate</th>
                    </tr>
                </thead>
                <tbody>
                    {props.products.map(prod =>
                        <tr key={prod.id}>
                            <td>{prod.id}</td>
                            <td>{prod.name} {prod.weight} kg</td>
                            <td>{prod.desc}</td>
                            <td>{prod.cost.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</td>
                            <td>{prod.categoryId}</td>
                            <td>{prod.createdDate}</td>
                            <td>{prod.updatedDate}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.page || 1) - 1;
    const nextStartDateIndex = (props.page || 1) + 1;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/product/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/product/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.products,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Product);