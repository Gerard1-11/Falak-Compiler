;; WebAssembly text format code generated by the falak compiler.

(module
 (import "falak" "printi" (func $printi (param i32) (result i32)))
 (import "falak" "printc" (func $printc (param i32) (result i32)))
 (import "falak" "prints" (func $prints (param i32) (result i32)))
 (import "falak" "println" (func $println (result i32)))
 (import "falak" "readi" (func $readi (result i32)))
 (import "falak" "reads" (func $reads (result i32)))
 (import "falak" "new" (func $new (param i32) (result i32)))
 (import "falak" "size" (func $size (param i32) (result i32)))
 (import "falak" "add" (func $add (param i32) (param i32) (result i32)))
 (import "falak" "get" (func $get (param i32) (param i32) (result i32)))
 (import "falak" "set" (func $set (param i32) (param i32) (param i32) (result i32)))

	(func $sqr
		(param $x i32)
		(result i32)
		(local $_temp i32)
		local.get $x
		local.get $x
		i32.mul
		return
i32.const 0
		
)
	(func
		(export "main")
		(result i32)
		(local $_temp i32)
		(local $array i32)
		i32.const 0
		call $new
		local.set $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		i32.const 1
		call $add
		drop
		i32.const 2
		local.get $_temp
		local.get $_temp
		i32.const 3
		call $add
		drop
		call $sqr
		i32.mul
		i32.const 2
		i32.add
		call $add
		drop
		local.set $array
		local.get $array
		i32.const 1
		call $get
		call $printi
		drop
i32.const 0
		
))
