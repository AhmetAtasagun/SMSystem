'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { createSale } from '@/redux/slices/saleSlice';
import { fetchProducts } from '@/redux/slices/productSlice';
import Link from 'next/link';

export default function NewSalePage() {
  const router = useRouter();
  const dispatch = useDispatch<AppDispatch>();
  const { loading, error } = useSelector((state: RootState) => state.sales);
  const { products } = useSelector((state: RootState) => state.products);
  
  const [productId, setProductId] = useState('');
  const [quantity, setQuantity] = useState('1');
  const [price, setPrice] = useState('');
  const [customerName, setCustomerName] = useState('');
  const [selectedProduct, setSelectedProduct] = useState<any>(null);
  
  useEffect(() => {
    dispatch(fetchProducts());
  }, [dispatch]);
  
  useEffect(() => {
    if (productId && products.length > 0) {
      const product = products.find(p => p.id.toString() === productId);
      if (product) {
        setSelectedProduct(product);
        setPrice(product.price.toString());
      }
    } else {
      setSelectedProduct(null);
      setPrice('');
    }
  }, [productId, products]);
  
  const calculateTotal = () => {
    if (price && quantity) {
      return (parseFloat(price) * parseInt(quantity)).toFixed(2);
    }
    return '0.00';
  };
  
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    const saleData = {
      productId: parseInt(productId),
      quantity: parseInt(quantity),
      price: parseFloat(price),
      customerName,
    };
    
    const result = await dispatch(createSale(saleData));
    if (result.meta.requestStatus === 'fulfilled') {
      router.push('/dashboard/sales');
    }
  };
  
  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Yeni Satış Kaydet</h1>
        <Link href="/dashboard/sales" className="btn btn-secondary">
          Geri Dön
        </Link>
      </div>
      
      <div className="card">
        {error && (
          <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded mb-4">
            {error}
          </div>
        )}
        
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div className="space-y-2">
              <label htmlFor="product" className="block font-medium">Ürün</label>
              <select
                id="product"
                className="input"
                value={productId}
                onChange={(e) => setProductId(e.target.value)}
                required
              >
                <option value="">Ürün Seçin</option>
                {products.map((product) => (
                  <option key={product.id} value={product.id}>
                    {product.name} - {product.price.toFixed(2)} TL
                  </option>
                ))}
              </select>
            </div>
            
            <div className="space-y-2">
              <label htmlFor="quantity" className="block font-medium">Miktar</label>
              <input
                id="quantity"
                type="number"
                min="1"
                className="input"
                value={quantity}
                onChange={(e) => setQuantity(e.target.value)}
                required
              />
            </div>
            
            <div className="space-y-2">
              <label htmlFor="price" className="block font-medium">Birim Fiyat (TL)</label>
              <input
                id="price"
                type="number"
                step="0.01"
                min="0"
                className="input"
                value={price}
                onChange={(e) => setPrice(e.target.value)}
                required
              />
            </div>
            
            <div className="space-y-2">
              <label htmlFor="customerName" className="block font-medium">Müşteri Adı</label>
              <input
                id="customerName"
                type="text"
                className="input"
                value={customerName}
                onChange={(e) => setCustomerName(e.target.value)}
                required
              />
            </div>
          </div>
          
          {selectedProduct && (
            <div className="bg-gray-50 p-4 rounded border mt-4">
              <h3 className="font-medium mb-2">Satış Özeti</h3>
              <div className="grid grid-cols-2 gap-2 text-sm">
                <div>Ürün:</div>
                <div>{selectedProduct.name}</div>
                
                <div>Kategori:</div>
                <div>{selectedProduct.categoryName}</div>
                
                <div>Miktar:</div>
                <div>{quantity}</div>
                
                <div>Birim Fiyat:</div>
                <div>{parseFloat(price).toFixed(2)} TL</div>
                
                <div className="font-medium">Toplam Tutar:</div>
                <div className="font-medium">{calculateTotal()} TL</div>
              </div>
            </div>
          )}
          
          <div className="pt-4">
            <button 
              type="submit" 
              className="btn btn-primary w-full md:w-auto"
              disabled={loading}
            >
              {loading ? 'Kaydediliyor...' : 'Satışı Kaydet'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}