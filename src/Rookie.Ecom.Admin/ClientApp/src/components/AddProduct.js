import React, { Component } from 'react';
import axios from 'axios';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/AddProduct';



class AddProduct extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        /*console.log(this.props.match.params.page);
        const page = parseInt(this.props.match.params.page, 5) || 0;
        console.log(page);
        this.props.requestAddCategories(page);*/
    }

    render() {
        return (
            <div>
                <h1>Add Product</h1>
                {renderAddProductFormat(this.props)}
            </div>
        );
    }
}

function renderAddProductFormat(props) {
    return <div className="mb-3">
        <p>Name</p>
        <input type="text" id="name" />

        <p className="mt-3">Description</p>
        <textarea id="desc" name="desc" cols="30" rows="5" className="form-control"></textarea>

        <p className="mt-3">Price</p>
        <input type="number" id="price" />

        <p className="mt-3">Weight</p>
        <input type="number" id="weight" />
        <br />

        <p className="mt-3">InStock</p>
        <input type="number" id="inStock" />

        <p className="mt-3">CategotyId</p>
        <input type="text" id="categotyId" />
        <br />

        <p className="mt-3">BrandId</p>
        <input type="text" id="brandId" />
        <br />

       

        <button className="btn btn-dark mt-3"
            onClick={() => props.addProduct(document.getElementById("name").value,
                document.getElementById("desc").value,
                document.getElementById("price").value,
                document.getElementById("inStock").value,
                document.getElementById("categotyId").value,
                document.getElementById("brandId").value,
                document.getElementById("weight").value
            )}
        >Add Product</button>
    </div>
}


export default connect(
    state => state.addProduct,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(AddProduct);