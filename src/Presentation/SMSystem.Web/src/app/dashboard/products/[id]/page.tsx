'use client';

import { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { fetchProductById, clearCurrentProduct } from '@/redux/slices/productSlice';
import Link from 'next/link';

export default function ProductDetailPage({ params }: { params: { id: string } }) {
  const dispatch = useDispatch<AppDispatch>();
  const { product, loading, error } = useSelector((state: RootState) => state.products);
  const productId = parseInt(params.id);

  useEffect(() => {
    dispatch(fetchProductById(productId));
    
    return () => {
      dispatch(clearCurrentProduct());
    };
  }, [dispatch, productId]);

  if (loading) {
    return <div className="text-center py-4">Yükleniyor...</div>;
  }

  if (error) {
    return <div className="text-red-500 text-center py-4">{error}</div>;
  }

  if (!product) {
    return <div className="text-center py-4">Ürün bulunamadı</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">{product.name}</h1>
        <div className="space-x-2">
          <Link href={`/dashboard/products/${product.id}/edit`} className="btn btn-primary">
            Düzenle
          </Link>
          <Link href="/dashboard/products" className="btn btn-secondary">
            Geri Dön
          </Link>
        </div>
      </div>

      <div className="card">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div>
            <h2 className="text-xl font-semibold mb-4">Ürün Bilgileri</h2>
            <div className="space-y-3">
              <div>
                <span className="font-medium">Ürün Adı:</span> {product.name}
              </div>
              <div>
                <span className="font-medium">Kategori:</span> {product.categoryName}
              </div>
              <div>
                <span className="font-medium">Fiyat:</span> {product.price.toFixed(2)} TL
              </div>
              <div>
                <span className="font-medium">Açıklama:</span>
                <p className="mt-1">{product.description}</p>
              </div>
            </div>
          </div>
          
          <div>
            {product.image ? (
              <div>
                <h2 className="text-xl font-semibold mb-4">Ürün Görseli</h2>
                <img 
                  src={product.image} 
                  alt={product.name} 
                  className="w-full max-h-64 object-contain border rounded"
                />
              </div>
            ) : (
              <div className="border rounded p-4 text-center text-gray-500">
                Ürün görseli bulunmamaktadır
              </div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}