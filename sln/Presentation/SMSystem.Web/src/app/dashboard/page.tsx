'use client';

import { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { fetchProducts } from '@/redux/slices/productSlice';
import { fetchCategories } from '@/redux/slices/categorySlice';
import { fetchSales } from '@/redux/slices/saleSlice';
import Link from 'next/link';

export default function DashboardPage() {
  const dispatch = useDispatch<AppDispatch>();
  const { products, loading: productsLoading } = useSelector((state: RootState) => state.products);
  const { categories, loading: categoriesLoading } = useSelector((state: RootState) => state.categories);
  const { sales, loading: salesLoading } = useSelector((state: RootState) => state.sales);

  useEffect(() => {
    dispatch(fetchProducts());
    dispatch(fetchCategories());
    dispatch(fetchSales());
  }, [dispatch]);

  return (
    <div className="space-y-6">
      <h1 className="text-2xl font-bold">Yönetim Paneli</h1>
      
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <div className="card">
          <h2 className="text-xl font-semibold mb-4">Ürünler</h2>
          <p className="text-3xl font-bold text-primary-600 mb-4">
            {productsLoading ? '...' : products.length}
          </p>
          <Link href="/dashboard/products" className="btn btn-primary block text-center">
            Ürünleri Yönet
          </Link>
        </div>
        
        <div className="card">
          <h2 className="text-xl font-semibold mb-4">Kategoriler</h2>
          <p className="text-3xl font-bold text-primary-600 mb-4">
            {categoriesLoading ? '...' : categories.length}
          </p>
          <Link href="/dashboard/categories" className="btn btn-primary block text-center">
            Kategorileri Yönet
          </Link>
        </div>
        
        <div className="card">
          <h2 className="text-xl font-semibold mb-4">Satışlar</h2>
          <p className="text-3xl font-bold text-primary-600 mb-4">
            {salesLoading ? '...' : sales.length}
          </p>
          <Link href="/dashboard/sales" className="btn btn-primary block text-center">
            Satışları Yönet
          </Link>
        </div>
      </div>
      
      <div className="card">
        <h2 className="text-xl font-semibold mb-4">Hızlı İşlemler</h2>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <Link href="/dashboard/products/new" className="btn btn-secondary block text-center">
            Yeni Ürün Ekle
          </Link>
          <Link href="/dashboard/sales/new" className="btn btn-secondary block text-center">
            Yeni Satış Kaydet
          </Link>
          <Link href="/dashboard/categories/new" className="btn btn-secondary block text-center">
            Yeni Kategori Ekle
          </Link>
          <Link href="/dashboard/sales/report" className="btn btn-secondary block text-center">
            Satış Raporu İndir
          </Link>
        </div>
      </div>
    </div>
  );
}