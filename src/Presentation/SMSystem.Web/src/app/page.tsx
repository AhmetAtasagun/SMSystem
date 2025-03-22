import Link from 'next/link';

export default function Home() {
  return (
    <main className="min-h-screen flex flex-col items-center justify-center p-4">
      <div className="card max-w-md w-full text-center">
        <h1 className="text-2xl font-bold text-primary-700 mb-6">SM System Yönetim Paneli</h1>
        <p className="mb-8 text-gray-600">Stok ve satış yönetimi için geliştirilmiş yönetim paneline hoş geldiniz.</p>
        
        <div className="space-y-4">
          <Link href="/login" className="btn btn-primary w-full block">
            Giriş Yap
          </Link>
          {/* <div className="flex space-x-4">
            <Link href="/products" className="btn btn-secondary flex-1">
              Ürünler
            </Link>
            <Link href="/categories" className="btn btn-secondary flex-1">
              Kategoriler
            </Link>
            <Link href="/sales" className="btn btn-secondary flex-1">
              Satışlar
            </Link>
          </div> */}
        </div>
      </div>
    </main>
  );
}